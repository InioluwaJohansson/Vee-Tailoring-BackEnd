﻿namespace Vee_Tailoring.Models.DTOs;

public class CreateAddressDto
{
    public string NumberLine { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
}
public class GetAddressDto
{
    public int Id { get; set; }
    public string NumberLine { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string? PostalCode { get; set; }
}
public class UpdateAddressDto
{
    public string NumberLine { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
}
