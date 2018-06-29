using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core;
using LWG.Core.Models;

namespace LWG.Business
{
    public class AudioBiz
    {
        private LudwigContext dbContext;

        public AudioBiz()
        {
            dbContext = new LudwigContext();
        }
        // get audio by Id
        public lwg_Audio GetAudioById(int audioId)
        {
            return dbContext.lwg_Audio.Where(a => a.AudioId == audioId).FirstOrDefault();
        }
        // add audios into lwg_Audio
        public void AddCatalogAudio(List<lwg_Audio> audioList)
        {
            dbContext.lwg_Audio.AddRange(audioList);
            dbContext.SaveChanges();
        }

        // delete a audio from lwg_Audio
        public void DeleteCatalogAudio(int audioId)
        {
            dbContext.lwg_Audio.Remove(dbContext.lwg_Audio.Where(v => v.AudioId == audioId).SingleOrDefault());
            dbContext.SaveChanges();
        }

        // update a audio
        public bool UpdateCatalogAudio(lwg_Audio audio)
        {
            lwg_Audio _audio = dbContext.lwg_Audio.Where(v => v.AudioId == audio.AudioId).FirstOrDefault();
            if (_audio != null)
            {
                _audio.SoundFile = audio.SoundFile;
                _audio.DisplayOrder = audio.DisplayOrder;
                _audio.CatalogId = audio.CatalogId;

                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_Audio GetSoundFile(int productId)
        {
            return dbContext.lwg_Audio.Where(a => a.CatalogId == productId).OrderBy(a => a.DisplayOrder).ThenByDescending(a => a.AudioId).FirstOrDefault();
        }

        public bool DeleteAudiosById(int catalogId)
        {
            List<lwg_Audio> audioList = dbContext.lwg_Audio.Where(a => a.CatalogId == catalogId).ToList();
            if (audioList != null && audioList.Count > 0)
            {
                dbContext.lwg_Audio.RemoveRange(audioList);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<lwg_Audio> GetAllSoundFiles(int productId)
        {
            return dbContext.lwg_Audio.Where(p => p.CatalogId == productId).ToList();
        }
    }
}
