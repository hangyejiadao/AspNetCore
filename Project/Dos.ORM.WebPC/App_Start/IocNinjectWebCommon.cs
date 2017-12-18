/*****************************************************************************************************
 * �������Ȩ��Quber���У�All Rights Reserved (C) 2016-2088
 * ��ϵ�����䣺qubernet@163.com
 *****************************************************************************************************
 * �����ռ䣺Dos.ORM.Web
 * �����ƣ�IocNinjectWebCommon
 * ����ʱ�䣺2016-9-22 11:36:01
 * �����ˣ�Quber
 * ����˵����
 *****************************************************************************************************
 * �޸��ˣ�
 * �޸�ʱ�䣺
 * �޸�˵����
*****************************************************************************************************/

using System;
using System.Web;
using Dos.ORM.WebPC;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IocNinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(IocNinjectWebCommon), "Stop")]

namespace Dos.ORM.WebPC
{
    /// <summary>
    /// ��������ע�����ã����಻��Ҫ��Global�ļ���ע�ᣬ������Global��Application_Start����ִ�У�
    /// </summary>
    public static class IocNinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// ����Ӧ�ã�ע�⣬�÷���������Global��Application_Start����ִ�У�
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// ֹͣӦ��
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// ����kernelӦ�ö���
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            /*
             * ������δ�������ã�
             *      �����������ʹ�õ�������ע��ķ�ʽ������ʱ��ӿڳ�Ա������Ϊprivate��
             *      ��ô��ʱ�����Ҫ����������δ��롣
             */
            kernel.Settings.InjectNonPublic = true;

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// ע��󶨷���
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            IocNinjectMapping.SetupResolveRules(kernel);
        }
    }
}
