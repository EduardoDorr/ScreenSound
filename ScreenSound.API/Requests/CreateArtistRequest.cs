using System.ComponentModel.DataAnnotations;

namespace ScreenSound.API.Requests;

public sealed record CreateArtistRequest([Required]string Name, [Required]string Bio, string? ProfilePhoto);
