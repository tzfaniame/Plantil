using Plantil.Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Plantil.Core
{
    [PlantGenusAndFamilyHasToMatchEnum]
    public class PlantForCreateDto : IValidatableObject
    {
        //public Guid Id { get; set; } it is not consumer responsbility suplide id

        [Required(ErrorMessage = "שם צמח הוא שדה חובה")]
        [MaxLength(50,ErrorMessage = "שם צמח לא יעלה על 50 תווים")]
        public string Name { get; set; }

        [Required(ErrorMessage = "שם מין הוא שדה חובה")]
        [MaxLength(50, ErrorMessage = "שם צמח לא יעלה על 50 תווים")]
        public string Genus { get; set; }

       
        public string Family { get; set; }

        [Required(ErrorMessage = "תאריך שתילה הוא שדה חובה")]
        public DateTime PlantingDate { get; set; }

        [Required(ErrorMessage = "אופן השתילה הוא שדה חובה")]
        public MultiplicationType Multiplication { get; set; }

        public ICollection<ExperimentForCreateDto> Experiments { get; set; }
            = new List<ExperimentForCreateDto>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Enum.IsDefined(typeof(GenusType), Genus)) {

                yield return new ValidationResult(
                    "the value of Genus is not in list",
                    new[] { "PlantForCreateDto" }
                    );
            }
        }
    }
}
