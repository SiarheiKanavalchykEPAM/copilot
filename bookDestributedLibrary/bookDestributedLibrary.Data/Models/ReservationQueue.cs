// Class for Reservation Queue table with fields: ReservationId (Primary key), BookId (Foreign key to Book table), UserId (Foreign key to User table), Reservation Date// using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace bookDestributedLibrary.Data.Models;

public class ReservationQueue
{
    [Key]
    public int ReservationId { get; set; }
    public DateTime ReservationDate { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }

    [ForeignKey("BookId")]
    public Book Book { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}