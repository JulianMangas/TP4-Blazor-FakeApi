using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using TP4BlazorHybrid.Models;

namespace TP4BlazorHybrid.Services;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Product>?> GetProducts()
    {
        return await _http.GetFromJsonAsync<List<Product>>("products");
    }
}
