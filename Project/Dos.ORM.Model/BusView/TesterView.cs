/*****************************************************************************************************
 * 本代码版权归成都科信所有，All Rights Reserved (C) 2017-2088				     
 * 联系人邮箱：alqs.cool@foxmail.com									     
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.BusView									     
 * 类名称：TesterView										     				
 * 创建时间：2017/2/24 14:15:36										     
 * 创建人：lqs（CDKX-ZC-2015051）								     
 * 创建说明：											     
 *****************************************************************************************************
 *	Change History                                                                               
 *****************************************************************************************************
 *	Date:		Author:		Description:
 *	----------	--------	--------------------------------------------------------------
 *   
 *
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dos.ORM.Model.Business;

namespace Dos.ORM.Model.BusView
{
    /// <summary>
    /// 
    /// </summary>
    public class TesterView : BUS_Tester
    {
        public string CutPath { get; set; }
    }
}
