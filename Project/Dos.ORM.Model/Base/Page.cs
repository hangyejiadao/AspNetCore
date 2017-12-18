using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dos.ORM.Model.Base
{
    public class Page<T>
    {
        public Page()
        {

        }
        /// <summary>
        /// 分页实体构造函数
        /// </summary>
        /// <param name="data">数据集</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">页显示数</param>
        /// <param name="totalcount">总条数</param>
        public Page(List<T> data, int pageindex, int pagesize, int totalcount)
        {
            this.CurrentPage = pageindex;
            this.ItemsPerPage = pagesize;
            this.TotalItems = totalcount;
            this.TotalPages = this.TotalItems / this.ItemsPerPage;
            if ((this.TotalItems % this.ItemsPerPage) != 0)
                this.TotalPages++;
            this.Items = data;
        }
        /// <summary>
        /// 当前第几页
        /// </summary>
        public long CurrentPage { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public long TotalPages { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public long TotalItems { get; set; }
        /// <summary>
        /// 每页显示多少条
        /// </summary>
        public long ItemsPerPage { get; set; }
        public List<T> Items { get; set; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrev { get { return (CurrentPage > 1); } }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext { get { return TotalPages > CurrentPage; } }

        public T[] ToArray()
        {
            if (Items == null)
            {
                return null;
            }

            return Items.ToArray();
        }

        public T this[int i]
        {
            get
            {
                return Items[i];
            }
            set
            {
                Items[i] = value;
            }
        }

        public int Count()
        {
            if (Items == null)
            {
                return 0;
            }
            return Items.Count;
        }

        public Page<T1> ToOther<T1>(IEnumerable<T1> elments)
        {
            var otherPage = new Page<T1>();
            otherPage.CurrentPage = this.CurrentPage;
            otherPage.TotalPages = this.TotalPages;
            otherPage.TotalItems = this.TotalItems;
            otherPage.ItemsPerPage = this.ItemsPerPage;
            otherPage.Items = new List<T1>();
            if (elments != null)
            {
                foreach (var elm in elments)
                {
                    otherPage.Items.Add(elm);
                }
            }
            return otherPage;
        }

        /// <summary>
        /// 获得当前显示的页面
        /// </summary>
        /// <param name="size">显示的页面数量</param>
        /// <returns></returns>
        public long[] GetCurrentIndexs(int size)
        {
            if (size <= 0)
            {
                return new long[] { };
            }
            long[] pages = new long[TotalPages < size ? TotalPages : size];

            if (TotalPages > size)
            {
                int mIndex = (int)Math.Ceiling(size / (double)2);

                if (CurrentPage <= mIndex)
                {
                    for (int i = 0; i < size; i++)
                    {
                        pages[i] = i + 1;
                    }
                }
                else if (TotalPages - CurrentPage >= mIndex)
                {
                    for (int i = 0; i < size; i++)
                    {
                        pages[i] = CurrentPage + mIndex - size + i;
                    }
                }
                else
                {
                    for (int i = 0; i < size; i++)
                    {
                        pages[i] = TotalPages - size + i + 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < TotalPages; i++)
                {
                    pages[i] = i + 1;
                }
            }

            return pages;
        }
    }
}
