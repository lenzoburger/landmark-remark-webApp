import { User } from './user';

// Marker Note model
export interface MarkerNote {
    id: number;
    longitude: number;
    latitude: number;
    note: string;
    createdDate: string;
    userId: number;
    
    user?: User;
}
