import { AuthService } from "../_service/auth.service";

export function appInitializer(authService: AuthService) {
    return () =>
      new Promise((resolve, reject) => {
            //console.log('refresh token on app start up');
            authService.refreshToken().subscribe().add(resolve);
        });
}
