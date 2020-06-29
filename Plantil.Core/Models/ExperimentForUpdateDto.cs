using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Plantil.Core
{
    public  class ExperimentForUpdateDto
    {
        [Required(ErrorMessage = "תאריך ניסוי הוא שדה חובה")]
        public DateTime ExperimentDate { get; set; }
        public LocationType Location { get; set; }
        [Required(ErrorMessage = "תאור הוא שדה חובה")]
        [MaxLength(200,ErrorMessage = "תאור הניסוי מוגבל ל200 תווים")]
        public string Description { get; set; }
    }
}
