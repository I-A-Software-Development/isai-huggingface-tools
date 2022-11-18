using Microsoft.AspNetCore.Mvc;
using Entities.DTOs;
using HuggingFace.Connectors;
using System.IO;

namespace HuggingFace.API.Controllers;

[Route("api/t2i")]
[ApiController]
public class Text2ImageController : ControllerBase
{
    public Text2ImageController()
    {
    }

    [HttpPost]
    public IActionResult PostT2I([FromBody] TextDescriptionDto req)
    {
        Text2ImageConenctor conenctor = new Text2ImageConenctor();
        Stream imgStream = conenctor.PostText2Image(req).Result;
        return File(imgStream, "image/jpeg");
    }
}
