using System;

namespace Api.Models
{
    [Serializable]
    public class CreateImageResponse
    {
    public bool Success { get; set; }
    public int Timestamp { get; set; }
    public bool Historical { get; set; }
    public string Base { get; set; }
    public string Date { get; set; }
    public Rates Rates { get; set; }
    }
}