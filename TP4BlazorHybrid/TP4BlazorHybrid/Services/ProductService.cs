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

    //Creando nuevo producto//
    public async Task<Product?> CreateProduct(Product product)
    {
        var response = await _http.PostAsJsonAsync("products", product);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        return null;
    }

    //Elimina un producto//
    public async Task<bool> DeleteProduct(int id)
    {
        var response = await _http.DeleteAsync($"products/{id}");

        return response.IsSuccessStatusCode;
    }

    //Editar un producto//
    public async Task<Product?> GetProductById(int id)
    {
        return await _http.GetFromJsonAsync<Product>($"products/{id}");
    }
    public async Task<Product?> UpdateProduct(int id, Product product)
    {
        var response = await _http.PutAsJsonAsync($"products/{id}", product);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        return null;
    }
}
