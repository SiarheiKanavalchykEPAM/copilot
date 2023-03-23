using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookDestributedLibrary.Data.Models;

public class LoanHistory
{
    [Key]
    public int LoanId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }

    [ForeignKey("BookId")]
    public Book Book { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}