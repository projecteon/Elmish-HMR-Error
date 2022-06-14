module Client.Navigation

open Elmish.UrlParser

/// The different pages of the application. If you add a new page, then add an entry here.
[<RequireQualifiedAccess>]
type Page =
  | Dashboard of int
  | Login
  | Logout
  | Teabags
  | Teabag of int

let toPath page =
  match page with
  | Page.Dashboard id -> sprintf "/dashboard/%i" id
  | Page.Login -> "/login"
  | Page.Logout -> "/logout"
  | Page.Teabags -> "/teabags"
  | Page.Teabag id -> sprintf "/teabags/%i" id

/// https://elmish.github.io/browser/routing.html
/// https://github.com/elmish/sample-react-navigation/blob/master/src/app.fs

/// The URL is turned into a Result.
let pageParser : Parser<Page -> Page,_> =
  oneOf
    [
      map Page.Dashboard (s "dashboard" </> i32)
      map Page.Login (s "login")
      map Page.Logout (s "logout")
      map Page.Teabags (s "teabags")
      map Page.Teabag (s "teabags" </> i32)
    ]

let urlParser location =
  parsePath pageParser location
