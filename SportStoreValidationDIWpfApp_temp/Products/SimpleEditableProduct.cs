﻿using System.ComponentModel.DataAnnotations;

namespace SportsStoreValidationDIWpfApp.Products
{
  public class SimpleEditableProduct: ValidatableBindableBase
  {
    private int _productId;
    private string _productName;
    private string _description;
    private decimal _price;
    private string _category;

    public int ProductId { get => _productId; set => SetProperty(ref _productId, value); }

    [Required(ErrorMessage = "Enter a Product Name")]
    public string ProductName { get => _productName; set => SetProperty(ref _productName, value); }

    [Required(ErrorMessage = "Enter a Description")]
    public string Description { get => _description; set => SetProperty(ref _description, value); }

    [Required(ErrorMessage = "Enter a positive price")]
    public decimal Price { get => _price; set => SetProperty(ref _price, value); }

    [Required(ErrorMessage = "Enter a Category")]
    public string Category { get => _category; set => SetProperty(ref _category, value); }
  }
}
