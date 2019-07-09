import { User } from './user';

// Marker Note model
export interface MarkerNote {
  id: number;
  longitude: number;
  latitude: number;
  note: string;
  userId?: number;
  username?: string;

  createdDate?: string;
  user?: User;
}
