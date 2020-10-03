using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceApp.BLL.Helpers.Attributes
{
    public class FileAttribute : ValidationAttribute
    {
        public string[] FileTypes { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is HttpPostedFileBase)
            {
                return ValidateSingleFile((HttpPostedFileBase)value);
            }
            else if (value is IEnumerable<HttpPostedFileBase>)
            {
                var propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
                var isRequired = propertyInfo.CustomAttributes.Where(x => x.AttributeType == typeof(RequiredAttribute)).FirstOrDefault() != null;
                return ValidateMultipleFiles(value, isRequired);
            }
            else
            {
                return new ValidationResult("The input type is not a file.");
            }
        }
        private ValidationResult ValidateSingleFile(HttpPostedFileBase file)
        {
            if (!isFileAllowedType(file))
            {
                return DisallowedFileTypeError(file);
            }
            return ValidationResult.Success;
        }
        private ValidationResult ValidateMultipleFiles(object value, bool isRequired)
        {
            IEnumerable<HttpPostedFileBase> files = (IEnumerable<HttpPostedFileBase>)value;
            if (isRequired && files.ToList()[0] == null)
            {
                return new ValidationResult("No files found.");
            }
            foreach (var file in files)
            {
                if (!isFileAllowedType(file))
                {
                    return DisallowedFileTypeError(file);
                }
            }
            return ValidationResult.Success;
        }
        private bool isFileAllowedType(HttpPostedFileBase file)
        {
            string fileType = file.ContentType.ToLower();
            return FileTypes.Length == 0 || FileTypes.Contains(fileType);
        }
        private ValidationResult DisallowedFileTypeError(HttpPostedFileBase file)
        {
            string fileName = file.FileName;
            return new ValidationResult($"{ fileName } is not an allowed file type.");
        }
    }
}
