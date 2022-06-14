module Index

open Elmish
open Fable.Core.JsInterop
open Fable.Remoting.Client
open Feliz
open Feliz.Bulma

open ClientTypes
open State
open Client.Navigation

importAll "./index.scss"

let viewPage model dispatch =
  match model.PageModel with
  | LoginPageModel m ->
    Client.Login.View.view m (LoginMsg >> dispatch)
  | DashboardPageModel m ->
    Client.Dashboard.View.view m (DashboardMsg >> dispatch)
  | TeabagsPageModel m ->
    Client.Teabags.View.view m (TeabagsMsg >> dispatch)
  | TeabagPageModel m ->
    Client.Teabag.View.view m (TeabagMsg >> dispatch)

let view model dispatch =
  Bulma.container [
    Client.Components.Navbar.View.view model.CurrentPage (true) model.Navbar (NavbarMsg >> dispatch)
    Html.hr [ prop.style [ style.marginTop 0 ] ]
    Html.div [ (viewPage model dispatch) ]
  ]
    

