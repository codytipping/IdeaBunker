﻿namespace IdeaBunker.ViewModels;

public class ViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserNameAndRank { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;    
    public int SecurityCount { get; set; } = 0;
    public EventViewModel Event { get; set; } = new();
}