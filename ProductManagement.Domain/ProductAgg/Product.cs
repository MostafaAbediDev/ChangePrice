using _0_FrameWork.Domain;

namespace ProductManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public string? Picture { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? Name { get; private set; }
        public string? UnitOfMeasurement { get; private set; }
        public long PriceInIran { get; private set; }
        public int DefaultCount { get; private set; }
        public bool IsRemoved { get; private set; }


        public Product(string? picture, string? pictureAlt, string? pictureTitle, 
            string? name, string? unitOfMeasurement, long priceInIran, int defaultCount)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Name = name;
            UnitOfMeasurement = unitOfMeasurement;
            PriceInIran = priceInIran;
            DefaultCount = defaultCount;
            IsRemoved = false;
        }

        public void Edit(string? picture, string? pictureAlt, string? pictureTitle,
            string? name, string? unitOfMeasurement, long priceInIran, int defaultCount)
        {
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Name = name;
            UnitOfMeasurement = unitOfMeasurement;
            PriceInIran = priceInIran;
            DefaultCount = defaultCount;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }

    }
}
