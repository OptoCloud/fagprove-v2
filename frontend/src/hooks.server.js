import { PUBLIC_BACKEND_API_BASE_URL } from '$env/static/public';

const CORS_HEADERS = {
  Origin: PUBLIC_BACKEND_API_BASE_URL,
  Methods: '*',
  Headers: '*',
};

export async function handle({ event, resolve }) {
  const response = await resolve(event);

  // Options request, handle in different function
  if (event.request.method === 'OPTIONS') {
    return handleOptions();
  }

  response.headers.append('Access-Control-Allow-Origin', CORS_HEADERS.Origin);

  return response;
}

async function handleOptions() {
  const headers = {
    'Access-Control-Allow-Origin': CORS_HEADERS.Origin,
    'Access-Control-Allow-Methods': CORS_HEADERS.Methods,
    'Access-Control-Allow-Headers': CORS_HEADERS.Headers,
  };

  return new Response(null, { headers });
}
