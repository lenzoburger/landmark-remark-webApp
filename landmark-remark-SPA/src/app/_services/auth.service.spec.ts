/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AuthService } from './auth.service';
import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';
import { User } from '../_models/user';

// Test Authentication service methods with mock http client
describe('Service: Auth', () => {
  const mockToken =
    // tslint:disable-next-line: max-line-length
    'eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzIiwidW5pcXVlX25hbWUiOiJrZXZpbmIiLCJuYmYiOjE1NjI0NTc2MzgsImV4cCI6MTU2MjU0NDAzOCwiaWF0IjoxNTYyNDU3NjM4fQ.AuiH5K33hKA8G3d1HZ2xsDgykrsLp4R3fOm5sA0sTyivz6ichTPp4zm8cwXfId2obCWwYm7gj936XOAS5BFqaQ';
  let mockService: AuthService;
  let mockBackend: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [AuthService]
    });
    mockService = TestBed.get(AuthService);
    mockBackend = TestBed.get(HttpTestingController);
  });

  afterEach(() => {
    mockBackend.verify();
  });

  // Angular default test
  it('should inject authentication service', inject(
    [AuthService],
    (service: AuthService) => {
      expect(service).toBeTruthy();
    }
  ));

  // Test user login and verify returned Token & user object
  describe('User Login', () => {
    it('returns JWT token and Current User', () => {
      const mockLoginCreds = { username: 'lencho', password: 'password123' };

      const mockResponseObject = {
        token: mockToken,
        userObject: {
          id: 3,
          username: 'lencho',
          email: 'lenchob@bigpie.com',
          createdDate: '2019-07-06T18:58:30.1888362'
        }
      };

      mockService.login(mockLoginCreds).subscribe(next => {
        expect(mockService.currentUser.username).toEqual(
          mockLoginCreds.username
        );
      });

      const request = mockBackend.expectOne(
        'http://localhost:5000/api/auth/login'
      );

      expect(request.request.method).toEqual('POST');

      request.flush(mockResponseObject);
    });
  });

  // Test user registration and verify returned newly created user
  describe('User Registration', () => {
    it('returns newly created user', () => {
      const mockRegistrationDetails: any = {
        username: 'burka_2019',
        email: 'karma@snailmail.com',
        password: 'securepwd#456'
      };

      const createdUser: User = {
        id: 1358,
        username: 'burka_2019',
        email: 'karma@snailmail.com',
        createdDate: '2019-07-07T16:35:30.199362'
      };

      mockService
        .register(mockRegistrationDetails)
        .subscribe((responseData: User) => {
          expect(responseData.username).toEqual(
            mockRegistrationDetails.username
          );
          expect(responseData.id).toEqual(1358);
        });

      const request = mockBackend.expectOne(
        'http://localhost:5000/api/auth/register'
      );

      expect(request.request.method).toEqual('POST');

      request.flush(createdUser);
    });
  });
});
