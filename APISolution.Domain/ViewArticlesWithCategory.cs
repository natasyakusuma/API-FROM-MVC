﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APISolution.Models;


public partial class ViewArticlesWithCategory
{
    [Column("ArticleID")]
    public int ArticleId { get; set; }

    [StringLength(255)]
    public string Title { get; set; } = null!;

    public string? Details { get; set; }

    public DateOnly PublishDate { get; set; }

    public bool IsApproved { get; set; }

    
    public string? Pic { get; set; }

    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(50)]
    public string? CategoryName { get; set; }
}
