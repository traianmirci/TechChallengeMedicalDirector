export interface UserDetailsSimple {
  id: number,
  name: string,
  username: string,
  postCount: number
}

export interface UsersList extends UserDetailsSimple {
  Array: UserDetailsSimple
}
