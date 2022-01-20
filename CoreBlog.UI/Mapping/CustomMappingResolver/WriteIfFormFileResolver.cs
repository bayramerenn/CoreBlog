using AutoMapper;
using CoreBlog.Business.DTOs;
using CoreBlog.Entity.Concrete;
using System;
using System.IO;

namespace CoreBlog.UI.Mapping.CustomMappingResolver
{
    public class WriteIfFormFileResolver : IValueResolver<WriterDto, Writer, string>
    {
        public string Resolve(WriterDto source, Writer destination, string destMember, ResolutionContext context)
        {
            if (source.WriterImage != null)
            {
                var extension = Path.GetExtension(source.WriterImage.FileName);
                var newImageName = Guid.NewGuid().ToString() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/" + newImageName);
                var stream = new FileStream(location, FileMode.Create);
                source.WriterImage.CopyTo(stream);
                destination.WriterImage = newImageName;

                return destination.WriterImage;
            }

            return null;
        }
    }
}