using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using TaxCalculator.Model.Dto;

namespace TaxCalculator.Web.ApiClient
{
    public class CalculatorApiClient : ICalculatorApiClient
    {
        private readonly string apiUrl;
        public CalculatorApiClient() {
            apiUrl = "https://localhost:7093/TaxCalculator/";
        }

        public async Task<GetCalculationsResponseDto> GetCalculationsAsync(GetCalculationsRequestDto requestDto)
        {
            var uri = new Uri(apiUrl + "GetCalculations");

            return await PostItAsync<GetCalculationsRequestDto, GetCalculationsResponseDto>(requestDto, uri); 
        }

        public async Task<CalculateResponseDto> CalculateAsync(CalculateRequestDto requestDto)
        {
            var uri = new Uri(apiUrl + "Calculate");

            return await PostItAsync<CalculateRequestDto, CalculateResponseDto>(requestDto, uri); 
        }

        private async Task<TO> PostItAsync<TI, TO>(TI value, Uri uri)
        {
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(value));
            content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("Application/json");
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(uri, content);
            var responseData = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TO>(responseData);
        }
         
    }
}
