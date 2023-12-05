export interface User {
  userName: string;
  role: Role;
  token?: string;
}
export enum Role {
  User = 'User',
  Admin = 'Admin',
}
