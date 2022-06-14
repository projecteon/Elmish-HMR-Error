module Client.Teabag.Types

type Model = {
  count: int
}

type Msg =
  | GetSuccess of int
