using OpenQA.Selenium;

namespace AutoWebSpa.RepositorioDeObjetos
{

    class PantallaDeLogin

    {
        public By inputUser = By.XPath("//*[@placeholder='Usuario']");
        public By inputPass = By.XPath("//*[@placeholder='Contraseña']");
        public By botonIniciarSession = By.XPath("//*[@type='submit']");
        public By inputBuscarModulo = By.XPath("//*[@placeholder='Buscar']");
    }
}
