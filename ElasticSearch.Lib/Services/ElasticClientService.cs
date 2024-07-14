// <copyright file="ElasticClientService.cs" company="Anonymous Corp.">
// Copyright (c) Anonymous Corp.. All rights reserved.
// </copyright>

namespace ElasticSearch.Lib.Services
{
    using System;
    using System.Configuration;
    using System.Threading.Tasks;
    using Elastic.Clients.Elasticsearch;
    using Elastic.Transport;
    using ElasticSearch.Lib.Objects;

    /// <summary>
    /// Configure the elastic search clients.
    /// </summary>
    public class ElasticClientService
    {
        /// <summary>
        /// Get the elastic clients.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To resonse <see cref="ElasticsearchClient"/>.</returns>
        public async Task<ElasticsearchClient> GetElasticClient()
        {
            ElasticSearchConfigurations elasticSearchConfigurations = await this.GetConfigurations();
            ElasticsearchClientSettings settings = new ElasticsearchClientSettings(new Uri(elasticSearchConfigurations.ElasticSearchURL));
            settings.CertificateFingerprint(elasticSearchConfigurations.CertificateThumbPrint);
            settings.ServerCertificateValidationCallback(CertificateValidations.AllowAll);
            settings.Authentication(new BasicAuthentication(elasticSearchConfigurations.Username, elasticSearchConfigurations.Password));
            settings.DefaultIndex(elasticSearchConfigurations.DefaultIndex);
            ElasticsearchClient client = new ElasticsearchClient(settings);
            return client;
        }

        /// <summary>
        /// Bind elastic search configurations.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. To return elastic search configurations.</returns>
        private Task<ElasticSearchConfigurations> GetConfigurations()
        {
            ElasticSearchConfigurations elasticSearchConfigurations = new ElasticSearchConfigurations();
            elasticSearchConfigurations.ElasticSearchURL = ConfigurationManager.AppSettings["ElasticSearchURL"];
            elasticSearchConfigurations.CertificateThumbPrint = ConfigurationManager.AppSettings["CertificateThumbPrint"];
            elasticSearchConfigurations.Username = ConfigurationManager.AppSettings["Username"];
            elasticSearchConfigurations.Password = ConfigurationManager.AppSettings["Password"];
            elasticSearchConfigurations.DefaultIndex = ConfigurationManager.AppSettings["DefaultIndex"];
            return Task.FromResult(elasticSearchConfigurations);
        }
    }
}
