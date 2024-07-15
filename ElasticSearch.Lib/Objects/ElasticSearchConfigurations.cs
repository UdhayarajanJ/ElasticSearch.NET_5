// <copyright file="ElasticSearchConfigurations.cs" company="Anonymous Corp.">
// Copyright (c) Anonymous Corp.. All rights reserved.
// </copyright>

namespace ElasticSearch.Lib.Objects
{
    using System.Configuration;
    using System.Threading.Tasks;

    /// <summary>
    /// Elastic search configuration details are bind.
    /// </summary>
    public class ElasticSearchConfigurations
    {
        /// <summary>
        /// Gets or sets elastic search URL.
        /// </summary>
        public string ElasticSearchURL { get; set; }

        /// <summary>
        /// Gets or sets certificate thumbprint.
        /// </summary>
        public string CertificateThumbPrint { get; set; }

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets default index.
        /// </summary>
        public string DefaultIndex { get; set; }
    }
}
