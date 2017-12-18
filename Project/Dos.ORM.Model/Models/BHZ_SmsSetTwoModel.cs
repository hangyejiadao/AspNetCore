using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Models
{
    public class BHZ_SmsSetTwoModel
    {

        
        public Guid TargetId { get; set; }


        public string TempletText { get; set; }
        

        //空Guid
        public Guid EmptyGuid { get; private set; }

        //发送对象       
        public List<BHZ_SmsSetTwo> SetTwoList { get; set; }

        //新增对象
        public BHZ_SmsSetTwo NewModel { get;private set; }

        //初始化
        public void Load_Init()
        {
            EmptyGuid = Guid.Empty;

            #region 初始化数据
            
            NewModel = new BHZ_SmsSetTwo()
            {
                ID = Guid.Empty,
                OrganID = TargetId,
                Seconds = "0",
                Minutes = "",
                Hours = "*",
                Day = "*",
                Month = "*",
                Week = "?",
                Year = "?",
                IsEnable = true
            };

            if (SetTwoList != null && SetTwoList.Count > 0)
            {
                TempletText =SetTwoList[0].TempletText;
            }

            #endregion

        }


        //保存初始化
        public void Save_Init()
        {

            if (SetTwoList != null && SetTwoList.Count > 0)
            {
                foreach (var item in SetTwoList)
                {
                    item.ID = Guid.NewGuid();
                    item.TempletText = TempletText;                   
                }
            }

            

        }

    }
}
