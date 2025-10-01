namespace WebApplication1.Models
{
    /// <summary>
    /// Modell for � vise feilinformasjon i en feilmeldingsside.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Id til foresp�rselen som feilet (kan v�re null).
        /// Brukes for � enklere finne igjen feilen i logger.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Returnerer true hvis RequestId har en verdi.
        /// Brukes i viewet til � avgj�re om RequestId skal vises.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

