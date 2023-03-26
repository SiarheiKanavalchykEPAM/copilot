using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookDestributedLibrary.Data.Models;

public class Book
{
    [Key]
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Genres { get; set; }
    public int NumberOfPages { get; set; }
    public string Tags { get; set; }
    public int ContributorId { get; set; }
    public int? CurrentKeeperId { get; set; }

    [ForeignKey("ContributorId")]
    public User Contributor { get; set; }
    [ForeignKey("CurrentKeeperId")]
    public User CurrentKeeper { get; set; }
}