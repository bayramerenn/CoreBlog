using AutoMapper;
using CoreBlog.Business.DTOs;
using CoreBlog.Entity.Concrete;
using CoreBlog.UI.Mapping.CustomMappingResolver;
using System;
using System.IO;

namespace CoreBlog.UI.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Blog, BlogDto>().ForMember(dest => dest.Category,opt => opt.Ignore());
            CreateMap<BlogDto, Blog>();
            CreateMap<Writer, WriterDto>().ForMember(dest => dest.WriterImage,opt => opt.Ignore());
            CreateMap<WriterDto, Writer>().
                    ForMember(dest => dest.WriterImage, opt => opt.MapFrom<WriteIfFormFileResolver>());
          
        }

        
    }
    //public class CustomResolver : IValueResolver<WriterDto, Writer, string>
    //{
    //    public string Resolve(WriterDto source, Writer destination, string destMember, ResolutionContext context)
    //    {
    //        if (source.WriterImage != null)
    //        {
    //            var extension = Path.GetExtension(source.WriterImage.FileName);
    //            var newImageName = Guid.NewGuid().ToString() + extension;
    //            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/"+newImageName);
    //            var stream = new FileStream(location, FileMode.Create);
    //            source.WriterImage.CopyTo(stream);
    //            destination.WriterImage = newImageName;

    //            return destination.WriterImage;

    //        }
            
    //        return null;
    //    }
    //}
}
