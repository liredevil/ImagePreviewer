using System.Web;
using System.Web.Optimization;

namespace ImagePreviewer
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/jquery-{version}.min.js",// fancybox
                        "~/Scripts/popper.min.js",///fancybox
                        "~/Scripts/DragAndDrop.js",
                        "~/Scripts/AutocompleteSearch.js",
                        "~/Scripts/ModalDialog.js",
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/tagsinput.js",///теги
                      "~/Scripts/bootstrap.min.js"));//fancybox

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/themes/base/all.css",
                      "~/Content/tagsinput.css"));///теги
        }
    }
}
