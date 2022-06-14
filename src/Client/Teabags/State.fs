module Client.Teabags.State

open Elmish

open Client.Teabags.Types

let init() =
  let initialModel = {
    count = 0
  }
  initialModel

let update (msg:Msg) model : Model*Cmd<Msg> =
  match msg with
  | _ -> model, Cmd.none
