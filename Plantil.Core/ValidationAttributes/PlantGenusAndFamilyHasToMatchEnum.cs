using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Plantil.API;

namespace Plantil.Core.ValidationAttributes
{
    public  class PlantGenusAndFamilyHasToMatchEnum : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var plant = (PlantForCreateDto)validationContext.ObjectInstance;

            //var validationResult = new List<ValidationResult>();

            //if (!Enum.IsDefined(typeof(GenusType), plant.Genus)) {

            //    validationResult.Add(
            //        new ValidationResult(
            //        "the value of Genus  is not in list",
            //        new[] { nameof(PlantForCreateDto) }));
            //}


            //if (!Enum.IsDefined(typeof(FamilyType), plant.Family))
            //{
            //    validationResult.Add(
            //        new ValidationResult(
            //        "the value of Family is not in list",
            //        new[] { nameof(PlantForCreateDto) }));
            //}

            //if (validationResult.Count == 0)
            //{
            //    return ValidationResult.Success;
            //}
            //else {
            //    return validationResult;
            //}

            if (!Enum.IsDefined(typeof(FamilyType), plant.Family))
            {
                return new ValidationResult(
                    "the value of Family  is not in list",
                    new[] { nameof(PlantForCreateDto) });
            }

            return ValidationResult.Success;
        }
    }
}
