using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IAmazonRekognition _rekognition;

        public AuthController(AppDbContext db, IAmazonRekognition rekognition)
        {
            _db = db;
            _rekognition = rekognition;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO dto)
        {
            const string collectionId = "even-collection";

            //Ensure collection exists-----------------------------------------

            if(dto.Photo == null || dto.Photo.Length == 0)
                return BadRequest("Photo is required.");

            // read photo as byte array-----------------------------------------
            byte[] photoBytes;
            var memoryStream = new MemoryStream();
            await dto.Photo.CopyToAsync(memoryStream);
            photoBytes = memoryStream.ToArray();

            // Search for the face in the Rekognition collection
            var searchRequest = new SearchFacesByImageRequest
            {
                CollectionId = collectionId,
                Image = new Image { Bytes = new MemoryStream(photoBytes) },
                FaceMatchThreshold = 90, // Adjust threshold as needed
                MaxFaces = 1
            };

            try
            {
                var searchResult = await _rekognition.SearchFacesByImageAsync(searchRequest);
                var match = searchResult.FaceMatches.FirstOrDefault();

                if (match == null)
                    return Unauthorized("No matching face found.");

                // Find user in DB
                var user = await _db.Users.FirstOrDefaultAsync(u => u.RekognitionFaceId == match.Face.FaceId);

                // Return user data, including photo as base64
                return Ok(new
                {
                    user.Id,
                    user.Name,
                    PhotoBase64 = Convert.ToBase64String(user.PhotoBlob)
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Authentication failed: " + ex.Message);
            }
        }
    }
}
