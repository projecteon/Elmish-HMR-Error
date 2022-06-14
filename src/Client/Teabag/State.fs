module Client.Teabag.State

open Elmish

open Client.Teabag.Types

let fetch id =
  Cmd.ofMsg (Msg.GetSuccess id)

let init() =
  let initialModel = {
    count = 0
  }
  initialModel, fetch

let update (msg:Msg) model : Model*Cmd<Msg> =
  match msg with
  | GetSuccess id -> { model with count = id }, Cmd.none