﻿using Microsoft.AspNetCore.Identity;

namespace MyResturants.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public List<Resturant> OwnedResturants { get; set; } = [];
}