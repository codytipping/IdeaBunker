﻿namespace IdeaBunker.Models;

public class DivisionEvent : Event
{
    public required string DivisionId { get; set; }
    public required string DivisionName { get; set; }
    public string? ClaimantId { get; set; } = string.Empty;
    public string? ClaimantName { get; set; } = string.Empty;
}