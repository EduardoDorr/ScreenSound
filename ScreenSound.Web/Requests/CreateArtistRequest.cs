using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Web.Requests;

public sealed record CreateArtistRequest([Required]string Name, [Required]string Bio, string? ProfilePhoto);