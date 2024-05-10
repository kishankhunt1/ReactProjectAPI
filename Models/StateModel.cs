﻿namespace ReactProjectApi.Models
{
    public class StateModel
    {
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
