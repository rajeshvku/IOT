using System.ComponentModel.DataAnnotations;

namespace Iot.Dto
{
    public class BuildingTemperature
    {
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(1)]
        public string Region { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(1)]
        public string Location { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(1)]
        public string Site { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(1)]
        public string Building { get; set; }
    }
}
