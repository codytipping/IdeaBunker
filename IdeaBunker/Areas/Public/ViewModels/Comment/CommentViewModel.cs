﻿using IdeaBunker.ViewModels;

namespace IdeaBunker.Areas.Public.ViewModels;

public class CommentViewModel : ViewModel
{
    public string? ProjectId { get; set; }
    public DateTime? Date { get; set; }
}