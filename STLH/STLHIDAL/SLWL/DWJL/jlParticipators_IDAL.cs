using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STLHMODEL.SLWL.DWJL;

namespace STLHIDAL.SLWL.DWJL
{
    
        /// <summary>
        /// 对外交流参与人员信息接口
        /// </summary>
        public interface jlParticipators_IDAL
        {
            /// <summary>
            /// 添加对外交流人员信息
            /// </summary>
            /// <param name="j_jlParticipators">对外交流人员信息</param>
            /// <returns>数据库受影响行数0错1对-1异常</returns>
            int insertJlParticipators(jlParticipators j_jlParticipators);

            /// <summary>
            /// 删除对外交流人员信息
            /// </summary>
            /// <param name="j_jlParticipators">对外交流人员信息</param>
            /// <returns>数据库受影响行数0错1对-1异常</returns>
            int deleteJlParticipators(string participatorId, string sljlId);

            /// <summary>
            /// 通过标识号查询对外交流人员基本信息
            /// </summary>
            /// <param name="userId">交流活动标识号</param>
            /// <returns>对外交流人员信息</returns>
            IList<jlParticipators> queryJlParticipators(string sljlId);
        }
    }

