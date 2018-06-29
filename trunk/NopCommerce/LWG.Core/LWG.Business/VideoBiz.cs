using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class VideoBiz
    {
        private LudwigContext dbContext;

        public VideoBiz()
        {
            dbContext = new LudwigContext();
        }
        // get video by Id
        public lwg_Video GetVideoById(int videoId)
        {
            return dbContext.lwg_Video.Where(v => v.VideoId == videoId).FirstOrDefault();
        }
        // add videos into lwg_Video
        public void AddCatalogVideo(List<lwg_Video> videoList)
        {
            dbContext.lwg_Video.AddRange(videoList);
            dbContext.SaveChanges();
        }

        // delete a video from lwg_Video
        public void DeleteCatalogVideo(int videoId)
        {
            dbContext.lwg_Video.Add(dbContext.lwg_Video.Where(v => v.VideoId == videoId).SingleOrDefault());
            dbContext.SaveChanges();
        }

        // update a video
        public bool UpdateCatalogVideo(lwg_Video video)
        {
            lwg_Video _video = dbContext.lwg_Video.Where(v => v.VideoId == video.VideoId).FirstOrDefault();
            if (_video != null)
            {
                _video.QTFile = video.QTFile;
                _video.DisplayOrder = video.DisplayOrder;
                _video.CatalogId = video.CatalogId;

                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        // delete Video by catalogId
        public bool DeleteVideosById(int catalogId)
        {
            List<lwg_Video> videoList = dbContext.lwg_Video.Where(v => v.CatalogId == catalogId).ToList();
            if (videoList != null && videoList.Count > 0)
            {
                dbContext.lwg_Video.RemoveRange(videoList);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
