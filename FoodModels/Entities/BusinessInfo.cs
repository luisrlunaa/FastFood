using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models.Entities
{
    public class BusinessInfo
    {
        [Key]
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string RNC { get; set; }
        public string PrinterName { get; set; }
        public string SystemColor { get; set; }
        public string LicenseActual { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string DefaultSystemColor { get; set; }
        public string WindowsUserName { get; set; }
        public string SqlFolderName { get; set; }
    }

    public class SystemColor
    {
        public string BackgroundHome { get; set; }
        public string BackgroundPrimaryWindows { get; set; }
        public string BackgroundSecondaryWindows { get; set; }
        public string BackgroundOthersWindows { get; set; }

        public string BackgroundHomeForeColor { get; set; }
        public string BackgroundPrimaryWindowsForeColor { get; set; }
        public string BackgroundSecondaryWindowsForeColor { get; set; }
        public string BackgroundOthersWindowsForeColor { get; set; }

        public ButtonsColor ButtonsColor { get; set; }
    }

    public class ButtonsColor
    {
        public string ButtonSuccess { get; set; }
        public string ButtonPrimary { get; set; }
        public string ButtonSecundary { get; set; }
        public string ButtonDanger { get; set; }
        public string OtherButtons { get; set; }

        public string ButtonSuccessForeColor { get; set; }
        public string ButtonPrimaryForeColor { get; set; }
        public string ButtonSecundaryForeColor { get; set; }
        public string ButtonDangerForeColor { get; set; }
        public string OtherButtonsForeColor { get; set; }
    }
}
