using com.sun.org.apache.xpath.@internal.operations;
using com.sun.swing.@internal.plaf.metal.resources;
using com.sun.xml.@internal.ws.wsdl.writer.document;
using EntityFrameWork;
using javax.ws.rs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;
using static com.sun.xml.@internal.bind.v2.runtime.unmarshaller.XsiNilLoader;
using static com.sun.xml.@internal.ws.api.config.management.policy.ManagementAssertion;
using static com.sun.xml.@internal.xsom.impl.Ref;
using static jdk.nashorn.@internal.codegen.CompilerConstants;
namespace BLL
{
    public interface CategoriesIBLL
    {
        List<Category> GetAllCategoriess();
        Category GetCategoryById(int Id);

        int AddCategory(Category c);
        void Updateategory(int Id, Category c);
        void Deleteategory(int Id);
        public void DecNumArticels(int id);
        public string getNameByCode(int code);


    }
}
