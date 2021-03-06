module ClientTypes

//open Server.Api.Dtos

type PageModel =
  | DashboardPageModel of Client.Dashboard.Types.Model
  | TeabagsPageModel of Client.Teabags.Types.Model
  | TeabagPageModel of Client.Teabag.Types.Model
  | LoginPageModel of Client.Login.Types.Model

type Model = {
    //User : UserData option
    PageModel : PageModel
    CurrentPage: Client.Navigation.Page
    Navbar: Client.Components.Navbar.Types.Model
  }

type Msg =
  | DashboardMsg of Client.Dashboard.Types.Msg
  | TeabagsMsg of Client.Teabags.Types.Msg
  | TeabagMsg of Client.Teabag.Types.Msg
  | LoginMsg of Client.Login.Types.Msg
  | LogOut
  | NavbarMsg of Client.Components.Navbar.Types.Msg
