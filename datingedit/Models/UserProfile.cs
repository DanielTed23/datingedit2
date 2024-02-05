namespace datingedit.Models

{
    public class UserProfile
    {
        /// Representerer brugerprofiloplysninger.
        
            public string Navn { get; set; }
            public string Postnummer { get; set; }
            public DateTime Fødselsdag { get; set; }
            public string Køn { get; set; }
            public string Adgangskode { get; set; } // Ny egenskab for adgangskoden
    }
}

