module State

open Elmish
open Elmish.Navigation
open Fable.Import

open ClientTypes
open Client.Navigation

let handleNotFound (model: Model) =
  Browser.Dom.console.error("Error parsing url: " + Browser.Dom.window.location.href)
  ( model, Navigation.modifyUrl (toPath Page.Login) )

/// The navigation logic of the application given a page identity parsed from the .../#info
/// information in the URL.
let urlUpdate (result: Page option) (model: Model) =
  match result with
  | None ->
    handleNotFound model
  | Some Page.Logout ->
    let m, cmd = Client.Login.State.init(), Cmd.none
    { model with PageModel = LoginPageModel m }, (Navigation.modifyUrl (toPath Page.Login))
  | Some Page.Login ->
    let m, cmd = Client.Login.State.init(), Cmd.none
    { model with PageModel = LoginPageModel m }, Cmd.map LoginMsg cmd
  | Some Page.Teabags ->
    let m = Client.Teabags.State.init()
    { model with PageModel = TeabagsPageModel m; CurrentPage = Page.Teabags }, Cmd.none
  | Some (Page.Teabag id) ->
    let m, cmd = Client.Teabag.State.init()
    { model with PageModel = TeabagPageModel m; CurrentPage = (Page.Teabag id) }, Cmd.map TeabagMsg (cmd id)
  | Some (Page.Dashboard id) ->
    let m = Client.Dashboard.State.init()
    { model with PageModel = DashboardPageModel m },  Cmd.none

let init page =
  let m, cmd = Client.Login.State.init(), Cmd.none
  let (navbar, navCmd) = Client.Components.Navbar.State.init()
  let model = { PageModel = LoginPageModel m; CurrentPage = Page.Login; Navbar = navbar }
  urlUpdate page model

let update msg model =
  match msg, model.PageModel with
  | NavbarMsg msg, _ ->
    let (navbar, navbarCmd) = Client.Components.Navbar.State.update msg model.Navbar
    { model with Navbar = navbar }, Cmd.map NavbarMsg navbarCmd
  | TeabagsMsg msg, TeabagsPageModel m ->
    let m, cmd = Client.Teabags.State.update msg m 
    { model with PageModel = TeabagsPageModel m }, Cmd.map TeabagsMsg cmd
  | TeabagsMsg _, _ ->
    model, Cmd.none
  | TeabagMsg msg, TeabagPageModel m ->
    let m, cmd = Client.Teabag.State.update msg m
    { model with PageModel = TeabagPageModel m }, Cmd.map TeabagMsg cmd
  | TeabagMsg _, _ ->
    model, Cmd.none
  | DashboardMsg msg, DashboardPageModel m ->
    let m, cmd = Client.Dashboard.State.update msg m
    { model with PageModel = DashboardPageModel m }, Cmd.map DashboardMsg cmd
  | DashboardMsg _, _ ->
    model, Cmd.none
  | LoginMsg _, _ ->
    model, Cmd.none
  | LogOut _, _ ->
    model, Cmd.none
  | _, _ ->
    model, Cmd.none
