namespace ApiBox.Options
{
    using System;

    public class EndpointOptions
    {
        public Uri Url { get; set; }

        public CertificateOptions Certificate { get; set; }
    }
}
